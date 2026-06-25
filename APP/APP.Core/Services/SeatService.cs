using APP.Core.Constants;
using DB;
using DB.Entities;

namespace APP.Core.Services;

public class SeatService(AppDbContext dbContext)
{
    private const int DefaultCountOfSeats = 32;
    private const int SeatsCountInRow = 4;
    
    public async Task<bool> GenerateEventSeats(Event entity)
    {
        if (entity.Id == Guid.Empty)
        {
            throw new Exception("Default id was given");
        }

        var seats = new List<Seat>();

        for (int i = 0; i < DefaultCountOfSeats; i++)
        {
            var seat = new Seat();
            
            seat.SetEntityDefValues();
            seat.EventId = entity.Id;
            seat.StatusId = SeatStatusConstants.Available;
            seat.Number = i + 1;
            seat.Row = GetSeatRowValue(i);
            
            seats.Add(seat);
        }

        await dbContext.AddRangeAsync(seats);
        return await dbContext.SaveChangesAsync() > 0;
    }

    private int GetSeatRowValue(int seatNumber)
    {
        var rowDivision = (float)seatNumber / SeatsCountInRow;
        return (int)rowDivision + 1;
    }
}