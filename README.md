# BookLog – Backend Architecture Foundation
BookLog is a clean, modular .NET backend designed as part of an academic assignment focused on object‑oriented analysis, design principles, and modern architectural patterns.
This project represents the starting point of a larger application and demonstrates how to structure a backend using Domain‑Driven Design (DDD), Clean Architecture, SOLID principles, and patterns such as Repository, Factory, and Result.

The goal of this assignment is not to build a full production system, but to create a scalable, maintainable foundation that can be expanded with additional features in future iterations.

# Project Purpose
BookLog is intended to serve as the backend for an application where users can register accounts, manage their book collections, track reading status, and organize series and volumes.
The current implementation focuses on:

Establishing a clean architectural structure

Implementing core domain models

Creating basic user management (register, fetch, list)

Demonstrating proper layering and separation of concerns

Applying design principles in a realistic but controlled scope

# Architecture Overview
The project follows a layered architecture inspired by Clean Architecture / Onion Architecture:

## 1. Presentation.Api
Exposes REST endpoints

Handles request/response models

Performs API‑level validation

## 2. Application
Contains use cases (e.g., RegisterUser, GetUser)

Implements orchestration logic

Uses the Result pattern for predictable error handling

Depends only on abstractions

## 3. Domain
Contains entities, value objects, and domain rules

Defines repository interfaces

Completely independent of infrastructure and frameworks

## 4. Infrastructure
Implements repositories

Handles database access and external integrations

Depends on Domain and Application, never the other way around

This structure ensures high testability, low coupling, and long‑term maintainability.
It also mirrors the architectural reasoning described in the assignment’s design document.

# Design Principles & Patterns Used
## SOLID Principles
SRP – Each class has a single responsibility

DIP – Higher layers depend on abstractions, not implementations

Separation of Concerns – API, application logic, domain, and infrastructure are clearly separated

## Design Patterns
Repository Pattern – Abstracts data access

Service Layer Pattern – Encapsulates use‑case logic

Factory Pattern – Creates domain objects consistently

Result Pattern – Provides structured success/error handling

These patterns were chosen because they fit the scope of the assignment and support a clean, pedagogical architecture.

## Why Some Patterns Were Not Used
More advanced patterns such as CQRS, Event Sourcing, or Mediator were intentionally not included.
They introduce unnecessary complexity for a small‑scale academic project and are better suited for distributed systems or high‑load environments.
The goal here is clarity, simplicity, and demonstrating good architectural fundamentals — not over‑engineering.

# Current Features
User Management
Register a new user

Fetch a user by ID

List all users

Domain Foundations
User aggregate

Value objects

Validation logic

Repository abstractions

This provides a solid base for future features such as book management, series tracking, ratings, and external API integration.

## Technologies
.NET 8

C#

Clean Architecture

Domain‑Driven Design

Dependency Injection

Repository Pattern

## Status
This project is not a complete application.
It is the initial architectural foundation created for an academic assignment.
