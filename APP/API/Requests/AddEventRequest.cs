namespace API.Requests;

public record AddEventRequest(
    string Title, 
    string Description, 
    DateTime StartDate, 
    string Location);