namespace API.Requests;

public record UpdateEventRequest(
    string Title, 
    string Description, 
    DateTime StartDate, 
    string Location);