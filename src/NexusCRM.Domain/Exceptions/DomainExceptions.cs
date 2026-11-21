namespace NexusCRM.Domain.Exceptions;

/// <summary>Base type for every expected business error. The API maps each subtype to an HTTP status.</summary>
public abstract class DomainException(string message) : Exception(message);

/// <summary>The record does not exist, or belongs to another tenant (we never reveal which).</summary>
public sealed class NotFoundException(string message) : DomainException(message);

/// <summary>The request clashes with current state, for example a duplicate email or a stale row version.</summary>
public sealed class ConflictException(string message) : DomainException(message);

/// <summary>The request is well formed but breaks a business rule, for example an illegal deal stage move.</summary>
public sealed class BusinessRuleException(string message) : DomainException(message);
