# C# Library Management System - Full-Stack TDD Approach

A complete full-stack Library Management System built with **.NET Web API** backend and **Angular** frontend, following Test-Driven Development (TDD) principles.

## 🏗️ **Architecture Overview**

```
LibraryManager/
├── LMS.BusinessLogic/          # .NET Business Logic Layer
├── LMS.WebAPI/                 # .NET Web API (REST Backend)
├── LMS.Tests/                  # .NET Unit Tests (NUnit)
├── lms-angular/                # Angular Frontend Application
├── TDDBookManagement.md        # TDD Process Documentation
├── DEPLOYMENT.md               # Docker & Render Deployment Guide
└── README.md                   # Project Overview
```

## 🚀 **Tech Stack**

### **Backend (.NET)**
- **.NET 8/9** - Modern .NET framework
- **ASP.NET Core Web API** - RESTful API development
- **NUnit** - Unit testing framework
- **Swagger/OpenAPI** - API documentation
- **CORS** - Cross-origin resource sharing
- **Dependency Injection** - Service management

### **Frontend (Angular)**
- **Angular 18** - Modern frontend framework
- **TypeScript** - Type-safe JavaScript
- **SCSS** - Advanced CSS styling
- **HTTP Client** - API communication
- **Router** - Client-side navigation
- **Responsive Design** - Mobile-first approach

### **DevOps & Deployment**
- **Docker** - Containerization
- **Docker Compose** - Multi-container orchestration
- **Nginx** - Reverse proxy and static file serving
- **Render** - Cloud deployment platform

### **Development Practices**
- **Test-Driven Development (TDD)** - Red-Green-Refactor cycle
- **Repository Pattern** - Data access abstraction
- **SOLID Principles** - Clean architecture
- **Modern UI/UX** - Professional design

## 🎯 **Features**

### **✅ Completed Features**
- **Book Management** - Full CRUD operations
- **REST API** - Complete backend API
- **Modern Frontend** - Responsive Angular application
- **Data Persistence** - In-memory storage with singleton pattern
- **Real-time Updates** - Live book count and list updates
- **Error Handling** - Comprehensive error management
- **API Documentation** - Swagger UI integration
- **Containerization** - Docker-ready for deployment

### **📚 Book Management System**
- **Add Books** - Create new book entries
- **View Books** - Display all books in responsive grid
- **Delete Books** - Remove books with confirmation
- **Book Count** - Real-time total book display
- **Duplicate Prevention** - ISBN-based uniqueness
- **Form Validation** - Client and server-side validation

## 🧪 **Testing**

### **Backend Testing**
- **27 Test Cases** covering all functionality
- **Data-driven Testing** with `[TestCase]` attributes
- **Edge Cases** and error scenarios
- **100% Coverage** for implemented features

### **Test Categories**
- Book addition and validation
- Book removal and existence checks
- Book retrieval and counting
- Duplicate prevention
- Error handling scenarios

## 🚀 **Getting Started**

### **Prerequisites**
- **.NET 8.0 SDK** or later
- **Node.js** and **npm**
- **Angular CLI** (`npm install -g @angular/cli`)
- **Docker Desktop** (for containerized deployment)

### **Option 1: Local Development**

#### **Backend Setup**
```bash
# Navigate to Web API directory
cd LMS.WebAPI

# Run the API
dotnet run
```
**API will be available at:** `http://localhost:5154`
**Swagger UI:** `http://localhost:5154/swagger`

#### **Frontend Setup**
```bash
# Navigate to Angular directory
cd lms-angular

# Install dependencies (if needed)
npm install

# Run the Angular app
ng serve
```
**Frontend will be available at:** `http://localhost:4200`

### **Option 2: Docker Deployment (Recommended)**

#### **Quick Start with Docker**
```bash
# Clone the repository
git clone https://github.com/ryanegauthier/c-sharp-library-management-tdd.git
cd c-sharp-library-management-tdd

# Build and run with Docker Compose
docker-compose up --build
```

#### **Access the Application**
- **Frontend:** http://localhost
- **Backend API:** http://localhost:5000
- **Swagger UI:** http://localhost:5000/swagger

#### **Docker Commands**
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
```

## ☁️ **Cloud Deployment**

### **Render Deployment**
This application is ready for deployment on Render with Docker support.

#### **Deploy to Render:**
1. **Connect your GitHub repository to Render**
2. **Create a new Web Service:**
   - **Name:** `lms-library-management`
   - **Repository:** Your GitHub repo
   - **Runtime:** `Docker`
   - **Environment Variables:** `ASPNETCORE_ENVIRONMENT=Production`
3. **Deploy!**

For detailed deployment instructions, see [DEPLOYMENT.md](DEPLOYMENT.md).

## 📖 **API Endpoints**

### **Books API (`/api/books`)**
- `GET /api/books` - Get all books
- `GET /api/books/{isbn}` - Get book by ISBN
- `POST /api/books` - Create new book
- `DELETE /api/books/{isbn}` - Delete book by ISBN
- `GET /api/books/count` - Get total book count
- `GET /api/books/exists/{isbn}` - Check if book exists

## 🏗️ **Architecture Details**

### **Backend Architecture**
- **Controllers** - REST API endpoints
- **Services** - Business logic layer
- **Repository Pattern** - Data access abstraction
- **Dependency Injection** - Service management
- **CORS Configuration** - Frontend integration

### **Frontend Architecture**
- **Components** - Reusable UI components
- **Services** - HTTP communication layer
- **Models** - TypeScript interfaces
- **Routing** - Client-side navigation
- **Responsive Design** - Mobile-first approach

### **Container Architecture**
- **Multi-stage Docker builds** - Optimized production images
- **Nginx reverse proxy** - API routing and static file serving
- **Docker Compose** - Service orchestration
- **Production-ready configuration** - Environment-specific settings

## 📚 **Documentation**

### **TDD Process**
- **TDDBookManagement.md** - Complete TDD implementation guide
- **Red-Green-Refactor** cycle documentation
- **Test case evolution** and refinement
- **Architecture improvements** and refactoring

### **API Documentation**
- **Swagger UI** - Interactive API documentation
- **OpenAPI Specification** - Machine-readable API docs
- **Endpoint examples** and testing

### **Deployment Documentation**
- **DEPLOYMENT.md** - Complete deployment guide
- **Docker configuration** and commands
- **Render deployment** instructions
- **Troubleshooting** and monitoring

## 🎨 **UI/UX Features**

### **Modern Design**
- **Clean, professional interface**
- **Responsive grid layout**
- **Hover effects and animations**
- **Color-coded status indicators**
- **Mobile-friendly design**

### **User Experience**
- **Intuitive navigation**
- **Form validation feedback**
- **Loading states**
- **Error message handling**
- **Success confirmations**

## 🔧 **Development Workflow**

### **TDD Cycle**
1. **Write failing tests** (Red)
2. **Implement minimal code** (Green)
3. **Refactor and improve** (Refactor)
4. **Repeat for new features**

### **Full-Stack Development**
1. **Backend API** development with TDD
2. **Frontend integration** with Angular
3. **End-to-end testing** and validation
4. **Containerization** and deployment

## 🚀 **Production Ready**

### **Backend Deployment**
- **Docker containerization** ✅
- **Environment configuration** ✅
- **Production settings** ✅
- **Database integration** ready
- **Health checks** implemented

### **Frontend Deployment**
- **Nginx serving** ✅
- **Production build** optimization ✅
- **Static file hosting** ✅
- **API proxy** configuration ✅
- **Gzip compression** ✅

### **DevOps Features**
- **Multi-container orchestration** ✅
- **Environment-specific builds** ✅
- **Logging and monitoring** ready
- **Auto-scaling** capable
- **CI/CD** ready

## 🎯 **Portfolio Highlights**

This project demonstrates:
- **Full-stack development** skills
- **TDD implementation** and best practices
- **Modern architecture** patterns
- **API design** and documentation
- **Frontend development** with Angular
- **Professional UI/UX** design
- **Containerization** and cloud deployment
- **Real-world application** development

## 📈 **Future Enhancements**

### **Planned Features**
- **Database Integration** - SQL Server/PostgreSQL
- **User Authentication** - JWT tokens
- **Advanced Search** - Book filtering and sorting
- **Book Categories** - Genre and classification
- **Borrowing System** - Check-in/check-out
- **User Management** - Admin and user roles

### **Technical Improvements**
- **Caching** - Redis integration
- **Logging** - Structured logging
- **Monitoring** - Application insights
- **CI/CD** - Automated deployment
- **Performance** - Optimization and scaling

---

**Built with ❤️ using TDD principles and modern full-stack development practices.**

**Ready for production deployment with Docker and Render!** 🐳☁️
