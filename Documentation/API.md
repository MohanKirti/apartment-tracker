# Apartment Tracker API Documentation

## Base URL
```
https://localhost:44300/api
```

## Authentication
All API endpoints require authentication using JWT tokens. Include the token in the Authorization header:
```
Authorization: Bearer {token}
```

## Endpoints

### Apartments
- **GET** `/apartments/manager/{managerId}` - Get apartments managed by a property manager
- **GET** `/apartments/{id}` - Get apartment details
- **GET** `/apartments/{id}/residents` - Get residents in an apartment
- **POST** `/apartments` - Create new apartment
- **PUT** `/apartments/{id}` - Update apartment
- **POST** `/apartments/{apartmentId}/residents/{userId}` - Add resident to apartment
- **DELETE** `/apartments/{apartmentId}/residents/{userId}` - Remove resident from apartment

### Expenses
- **GET** `/expenses/apartment/{apartmentId}` - Get all expenses for an apartment
- **GET** `/expenses/{id}` - Get expense details
- **POST** `/expenses` - Create new expense
- **PUT** `/expenses/{id}` - Update expense
- **DELETE** `/expenses/{id}` - Delete expense
- **GET** `/expenses/summary/apartment/{apartmentId}` - Get expense summary
- **GET** `/expenses/resident/{residentId}/summary` - Get resident payment summary

### Collections
- **GET** `/collections/apartment/{apartmentId}` - Get all items in apartment
- **GET** `/collections/{id}` - Get item details
- **POST** `/collections` - Create new collection item
- **PUT** `/collections/{id}` - Update collection item
- **DELETE** `/collections/{id}` - Delete collection item
- **GET** `/collections/apartment/{apartmentId}/category/{category}` - Get items by category
- **GET** `/collections/apartment/{apartmentId}/summary` - Get inventory summary

## Request/Response Format

All requests and responses use JSON format.

### Expense Model
```json
{
  "expenseId": 1,
  "apartmentId": 1,
  "createdByUserId": 3,
  "expenseName": "Monthly Rent",
  "category": "Rent",
  "amount": 3000.00,
  "expenseDate": "2025-05-01T00:00:00",
  "description": "May 2025 rent",
  "isShared": true,
  "splitType": "Equal",
  "paymentStatus": "Pending",
  "expenseSplits": [
    {
      "splitId": 1,
      "residentUserId": 4,
      "splitAmount": 1000.00,
      "splitPercentage": 33.33,
      "paymentStatus": "Pending"
    }
  ]
}
```

### Collection Model
```json
{
  "collectionId": 1,
  "apartmentId": 1,
  "itemName": "Dining Table",
  "category": "Furniture",
  "description": "Oak wood dining table",
  "purchaseDate": "2024-06-15T00:00:00",
  "purchasePrice": 800.00,
  "currentValue": 750.00,
  "owner": "Shared",
  "condition": "Good",
  "location": "Dining Room"
}
```

## Error Responses

### 400 Bad Request
```json
{
  "error": "Invalid request parameters"
}
```

### 401 Unauthorized
```json
{
  "error": "Authentication required"
}
```

### 403 Forbidden
```json
{
  "error": "Access denied"
}
```

### 404 Not Found
```json
{
  "error": "Resource not found"
}
```

### 500 Internal Server Error
```json
{
  "error": "An error occurred processing your request"
}
```

## Rate Limiting
- Rate limit: 1000 requests per hour per user
- Headers returned with each request:
  - `X-RateLimit-Limit`: 1000
  - `X-RateLimit-Remaining`: remaining requests
  - `X-RateLimit-Reset`: timestamp when limit resets