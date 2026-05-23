# Contributing to Apartment Tracker

Thank you for your interest in contributing to the Apartment Tracker project! This document provides guidelines and instructions for contributing.

## Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Help others learn and improve
- Report inappropriate behavior

## Getting Started

1. Fork the repository
2. Clone your fork: `git clone https://github.com/YOUR_USERNAME/apartment-tracker.git`
3. Create a feature branch: `git checkout -b feature/your-feature-name`
4. Make your changes
5. Commit with clear messages: `git commit -m "Add: Brief description of changes"`
6. Push to your fork: `git push origin feature/your-feature-name`
7. Create a Pull Request

## Commit Message Guidelines

Use the following format:
```
[Type]: [Brief description]

[Optional detailed description]
```

Types:
- **Add**: New feature or functionality
- **Fix**: Bug fix
- **Refactor**: Code restructuring without changing behavior
- **Docs**: Documentation updates
- **Test**: Adding or updating tests
- **Chore**: Maintenance tasks

Examples:
```
Add: Implement expense splitting algorithm
Fix: Resolve null reference exception in payment calculation
Docs: Update API documentation for collections endpoint
```

## Coding Standards

### C# Standards

- Follow Microsoft C# Coding Conventions
- Use meaningful variable and method names
- Add XML documentation comments to public methods
- Keep methods focused and single-responsibility
- Use async/await for I/O operations

Example:
```csharp
/// <summary>
/// Calculates the total expenses for an apartment in a given period
/// </summary>
/// <param name="apartmentId">The ID of the apartment</param>
/// <param name="startDate">Start date for the calculation</param>
/// <param name="endDate">End date for the calculation</param>
/// <returns>Total expenses amount</returns>
public decimal CalculateTotalExpenses(int apartmentId, DateTime startDate, DateTime endDate)
{
    // Implementation
}
```

### SQL Standards

- Use meaningful table and column names
- Include proper constraints and indexes
- Add comments for complex queries
- Follow naming conventions (PascalCase for tables, [brackets] for SQL Server)

## Pull Request Process

1. **Update Documentation**: Update README.md, API.md, or other docs if needed
2. **Add Tests**: Include unit tests for new functionality
3. **Code Review**: Address reviewer comments and suggestions
4. **No Conflicts**: Ensure your branch has no merge conflicts
5. **Clean Commits**: Squash unnecessary commits if needed

## Testing

- Write unit tests for business logic
- Test database migrations
- Verify API endpoints manually
- Test both success and error scenarios

## Reporting Issues

Use GitHub Issues to report bugs or suggest features:

- **Bug Report**: Include steps to reproduce, expected behavior, actual behavior
- **Feature Request**: Describe the feature, use cases, and potential benefits

## Questions?

Feel free to:
- Open an issue with your question
- Reach out to maintainers
- Check existing issues and discussions

## License

By contributing, you agree that your contributions will be licensed under the project's MIT License.

---

Thank you for helping improve Apartment Tracker! 🎉