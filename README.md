# Ticket Manager

A console-based Ticket Management Application built with .NET, demonstrating the implementation of Clean Architecture (Onion Architecture) principles and loose coupling.

## Overview

The Ticket Manager system allows users to seamlessly authenticate, view real-time available sports or entertainment matches, and manage their ticket bookings (booking and cancellation) dynamically. The application is strictly separated into decoupled layers to ensure maximum testability, maintainability, and readiness for future database migration.

## Architectural Structure

The project follows Clean Architecture boundaries, dividing the system into distinct layers where dependencies flow strictly inward:

- **Presentation Layer (UI & Program.cs):** Handles user interaction, console rendering, and horizontal/vertical feature slice routing. It acts as the application entry point and composition root.
- **Application Layer (Services):** Implements the core business rules and use cases (e.g., authentication validation, booking constraints). It exposes functionality via abstractions (Interfaces) to the presentation layer.
- **Infrastructure Layer (Repositories):** Manages data access and state persistence. Currently implemented as an In-Memory data store, fully decoupled via repository interfaces to allow seamless transition to SQL Server or any persistent database provider.
- **Domain Layer (Models):** Contains pure data structures and entities (Account, Match, Ticket) representing the system's core blueprints with zero external dependencies.
- **Helpers:** Provides global utility functions, such as regular expression validation for credentials, utilized across the presentation boundaries.

## Core Functionalities

### 1. User Authentication
- **Secure Registration:** Validates user inputs (emails and passwords) against strict format constraints before processing account creation.
- **User Login:** Authenticates existing credentials and establishes a stateful current user session using uniquely generated IDs.

### 2. Match Discovery
- Displays a dynamic real-time dashboard of available system matches.
- Exposes unique Ticket IDs, match titles, and calculated dynamic scheduling dates to eliminate user guesswork during interactions.

### 3. Booking Management
- **Ticket Booking:** Allocates specific tickets to the logged-in account, changing the global state and verifying availability rules.
- **Booking Cancellation:** Enables users to release their reserved tickets back to the available pool using their unique booking references.

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later

### Installation & Execution


1. Clone the repository:
   git clone [https://github.com/AnsElgyarDev/TicketManager.git](https://github.com/AnsElgyarDev/TicketManager.git)

2. Navigate to the project directory:
  cd TicketManager/TicketManager
3. Run the application:
   dotnet run
