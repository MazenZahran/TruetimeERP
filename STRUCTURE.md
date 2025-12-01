# TrueTime ERP - Project Folder Structure

Last Updated: November 27, 2025

## Overview
This document defines the standardized folder structure for the TrueTime ERP system.

## Current Structure

````````
TrueTime/
│
├── AccountingSystem/
│   ├── Models/                          # Data Transfer Objects & Domain Models
│   │   ├── StockItemData.vb
│   │   ├── InvoiceData.vb
│   │   ├── VoucherData.vb
│   │   └── CustomerData.vb
│   │
│   ├── Modules/                         # Business Logic & Utilities
│   │   ├── AccountingFunctions.vb
│   │   ├── StockFunctions.vb
│   │   └── ValidationHelpers.vb
│   │
│   ├── Reports/                         # Reporting Components
│   │   ├── StockBalancesReport.vb
│   │   ├── AccountStatementDetails2.vb
│   │   ├── ItemsSerialsReport.vb
│   │   └── FinancialReports/
│   │
│   ├── Documents/                       # Document Management
│   │   ├── Invoices/
│   │   ├── Vouchers/
│   │   └── Journals/
│   │       └── AccountingJardAddItem.vb
│   │
│   ├── Inventory/                       # Stock & Warehouse Management
│   │   ├── StockDocuments/
│   │   ├── ItemsSearchMenue.vb
│   │   └── Warehouses/
│   │
│   ├── Production/                      # Manufacturing & Production
│   │   └── ProductionDocument.vb
│   │
│   ├── CRM/                            # Customer Relationship Management
│   │   ├── Campaigns/
│   │   │   └── CampaignesByProductQuantity.vb
│   │   └── Subscriptions/
│   │       └── NewSubScriptions.vb
│   │
│   ├── Services/                        # Business Services Layer
│   │   ├── StockService.vb
│   │   ├── InvoiceService.vb
│   │   └── AccountingService.vb
│   │
│   └── ViewModels/                      # UI State Management
│
├── HRSystem/
│   ├── Models/                          # HR Data Models
│   │   ├── EmployeeData.vb
│   │   └── SalaryData.vb
│   │
│   ├── Modules/                         # HR Business Logic
│   │   └── HRFunctions.vb
│   │
│   ├── Payroll/                         # Salary & Compensation
│   │   └── Reports/
│   │       └── SalaryPosted.vb
│   │
│   ├── Attendance/                      # Time & Attendance
│   │   └── AttAdvancePayment.vb
│   │
│   ├── Recruitment/                     # Hiring & Onboarding
│   │
│   └── Performance/                     # Performance Management
│
├── FinanceSystem/                       # Financial Management (if separate)
│   ├── Models/
│   ├── GeneralLedger/
│   ├── Accounts/
│   └── Reports/
│
├── Shared/                              # Cross-Module Shared Components
│   ├── Models/                          # Common DTOs
│   ├── Utilities/                       # Helper Functions
│   ├── Constants/                       # Application Constants
│   ├── Enums/                          # Shared Enumerations
│   ├── Interfaces/                      # Contracts & Abstractions
│   └── Extensions/                      # Extension Methods
│
├── Data/                                # Data Access Layer
│   ├── Repositories/                    # Repository Pattern
│   ├── Context/                         # Database Context
│   └── Migrations/                      # Database Migrations
│
├── UI/                                  # User Interface Components
│   ├── Forms/
│   ├── Controls/
│   ├── Dialogs/
│   └── Views/
│
├── Configuration/                       # Application Configuration
│   ├── AppSettings/
│   ├── Security/
│   └── DatabaseConfig/
│
├── Reports/                             # Cross-Module Reporting
│   ├── Templates/
│   ├── Exports/
│   └── Generators/
│
└── Core/                                # Core Application Infrastructure
    ├── ApplicationEvents.vb
    ├── Startup/
    ├── DependencyInjection/
    └── Logging/
````````

# Response
