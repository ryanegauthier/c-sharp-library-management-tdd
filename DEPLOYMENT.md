# Deployment Guide - Library Management System

This guide covers deploying the full-stack Library Management System using Docker and Render.

## 🐳 Docker Deployment

### Prerequisites
- Docker Desktop installed
- Docker Compose installed

### Local Docker Deployment

1. **Clone the repository:**
```bash
git clone https://github.com/ryanegauthier/c-sharp-library-management-tdd.git
cd c-sharp-library-management-tdd
```

2. **Build and run with Docker Compose:**
```bash
docker-compose up --build
```

3. **Access the application:**
- **Frontend:** http://localhost
- **Backend API:** http://localhost:5000
- **Swagger UI:** http://localhost:5000/swagger

### Docker Commands

```bash
# Build images
docker-compose build

# Start services
docker-compose up

# Start in background
docker-compose up -d

# Stop services
docker-compose down

# View logs
docker-compose logs

# Rebuild and restart
docker-compose up --build --force-recreate
```

## ☁️ Render Deployment

### Option 1: Deploy API as Web Service + Frontend as Static Site (Recommended)

#### Backend API Deployment
1. **Connect your GitHub repository to Render**

2. **Create a new Web Service for the API:**
   - **Name:** `lms-api`
   - **Repository:** Your GitHub repo
   - **Branch:** `master`
   - **Root Directory:** Leave empty (root)
   - **Runtime:** `Docker`
   - **Dockerfile Path:** `./Dockerfile` (default)
   - **Note:** Render automatically handles build and start commands when Dockerfile Path is specified

#### Frontend Deployment
3. **Create a new Static Site for Angular:**
   - **Name:** `lms-frontend`
   - **Repository:** Your GitHub repo
   - **Branch:** `master`
   - **Root Directory:** `lms-angular`
   - **Build Command:** `npm install && npm run build`
   - **Publish Directory:** `dist/lms-angular/browser`

3. **Environment Variables for API:**
   ```
   ASPNETCORE_ENVIRONMENT=Production
   ```

4. **Deploy the API!**

5. **Update Frontend API URL:**
   After the API is deployed, update the API URL in `lms-angular/src/app/services/book.ts`:
   ```typescript
   private apiUrl = 'https://your-api-url.onrender.com/api/books';
   ```

6. **Deploy the Frontend!**

### Option 2: Deploy as Single Web Service with Docker Compose

**Note:** This option requires Render's Docker Compose support (if available) or manual configuration.

1. **Create a new Web Service:**
   - **Name:** `lms-fullstack`
   - **Repository:** Your GitHub repo
   - **Branch:** `master`
   - **Root Directory:** Leave empty (root)
   - **Runtime:** `Docker`
   - **Dockerfile Path:** `./Dockerfile` (default)
   - **Note:** For Docker Compose deployment, you may need to use Render's advanced settings or contact support

2. **Environment Variables:**
   ```
   ASPNETCORE_ENVIRONMENT=Production
   ```

## 🔧 Configuration

### Environment Variables

#### Backend (.NET Web API)
```bash
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://+:80
```

#### Frontend (Angular)
The frontend automatically uses relative URLs for API calls in production.

### Port Configuration

#### Option 1 (Separate Services):
- **Frontend:** Static site (no port needed)
- **Backend:** Port 80 (Render assigns external port)

#### Option 2 (Docker Compose):
- **Frontend:** Port 80 (default)
- **Backend:** Port 5000 (internal), proxied through nginx

## 📊 Monitoring

### Health Checks
- **API Health:** `GET /api/books/count`
- **Frontend:** Root URL should load Angular app

### Logs
```bash
# Docker logs
docker-compose logs webapi
docker-compose logs frontend

# Render logs
# Available in Render dashboard
```

## 🚀 Production Considerations

### Security
- ✅ HTTPS enabled (Render provides SSL)
- ✅ CORS configured for production
- ✅ Environment variables for sensitive data

### Performance
- ✅ Nginx with gzip compression
- ✅ Angular production build
- ✅ .NET optimized for production

### Scalability
- ✅ Stateless API design
- ✅ Containerized deployment
- ✅ Horizontal scaling ready

## 🔍 Troubleshooting

### Common Issues

1. **API not accessible from frontend:**
   - Check nginx proxy configuration
   - Verify API is running on correct port
   - Check CORS settings

2. **Angular routing not working:**
   - Ensure nginx configuration includes `try_files $uri $uri/ /index.html;`

3. **Build failures:**
   - Check Dockerfile syntax
   - Verify all dependencies are included
   - Check .dockerignore exclusions

### Debug Commands

```bash
# Check container status
docker-compose ps

# View container logs
docker-compose logs -f

# Access container shell
docker-compose exec webapi sh
docker-compose exec frontend sh

# Check network connectivity
docker network ls
docker network inspect lms-network
```

## 📈 Next Steps

### Database Integration
- Add PostgreSQL container
- Update BookRepository for database persistence
- Add Entity Framework migrations

### Authentication
- Implement JWT authentication
- Add user management
- Secure API endpoints

### Monitoring
- Add application insights
- Implement health checks
- Set up logging aggregation

---

**Your Library Management System is now ready for production deployment!** 🚀

*Last updated: September 4, 2025*
