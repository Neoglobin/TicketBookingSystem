namespace API.Requests;

public record UpdateOrderRequest(
    Guid EventId, Guid SeatId, Guid StatusId);