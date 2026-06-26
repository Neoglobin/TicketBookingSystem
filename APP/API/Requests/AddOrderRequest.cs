namespace API.Requests;

public record AddOrderRequest(
    Guid EventId, Guid SeatId);