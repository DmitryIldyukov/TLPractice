using Accommodations.Commands;
using Accommodations.Dto;

namespace Accommodations;

public static class AccommodationsProcessor
{
    private static BookingService _bookingService = new();
    private static Dictionary<int, ICommand> _executedCommands = new();
    private static int s_commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine("Booking Command Line Interface");
        Console.WriteLine("Commands:");
        Console.WriteLine("'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room");
        Console.WriteLine("'cancel <BookingId>' - to cancel a booking");
        Console.WriteLine("'undo' - to undo the last command");
        Console.WriteLine("'find <BookingId>' - to find a booking by ID");
        Console.WriteLine("'search <StartDate> <EndDate> <CategoryName>' - to search bookings");
        Console.WriteLine("'exit' - to exit the application");

        string input;
        while ((input = Console.ReadLine()) != "exit")
        {
            try
            {
                ProcessCommand(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string commandName = parts[0];
        DateTime startDate, endDate;
        CurrencyDto currency;

        switch (commandName)
        {
            case "book":
                if (parts.Length != 6)
                {
                    Console.WriteLine("Invalid number of arguments for booking.");
                    return;
                }

                // ƒобавил обработку невалидных дат
                if (!DateTime.TryParse( parts[ 3 ], out startDate ) )
                {
                    throw new ArgumentException( "Invalid start date format. Expected format: 'dd/mm/yyyy'" );
                }

                if ( !DateTime.TryParse( parts[ 4 ], out endDate ) )
                {
                    throw new ArgumentException( "Invalid end date format. Expected format: 'dd/mm/yyyy'" );
                }

                // ƒобавил обработку невалидной валюты (выбрасываетс€ ArgumentException)
                if ( !Enum.TryParse(parts[5], true, out currency ))
                {
                    throw new ArgumentException( $"Invalid currency {parts[ 5 ]}." );
                }
                

                BookingDto bookingDto = new()
                {
                    UserId = int.Parse(parts[1]),
                    Category = parts[2],
                    StartDate = startDate,
                    EndDate = endDate,
                    Currency = currency,
                };

                BookCommand bookCommand = new(_bookingService, bookingDto);
                bookCommand.Execute();
                _executedCommands.Add(++s_commandIndex, bookCommand);
                Console.WriteLine("Booking command run is successful.");
                break;

            case "cancel":
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid number of arguments for canceling.");
                    return;
                }

                Guid bookingId = Guid.Parse(parts[1]);
                CancelBookingCommand cancelCommand = new(_bookingService, bookingId);
                cancelCommand.Execute();
                _executedCommands.Add(++s_commandIndex, cancelCommand);
                Console.WriteLine("Cancellation command run is successful.");
                break;

            case "undo":
                // ƒобавил проверку на пустой массив команд перед отменой команды
                if (!_executedCommands.Any())
                {
                    Console.WriteLine("Command list is empty.");
                    break;
                }
                _executedCommands[s_commandIndex].Undo();
                _executedCommands.Remove(s_commandIndex);
                s_commandIndex--;
                Console.WriteLine("Last command undone.");

                break;
            case "find":
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid arguments for 'find'. Expected format: 'find <BookingId>'");
                    return;
                }
                // ƒобавил проверку на валидный bookingId
                if ( !Guid.TryParse( parts[ 1 ], out Guid id))
                {
                    throw new ArgumentException( "Invalid bookingId format.");
                }
                FindBookingByIdCommand findCommand = new(_bookingService, id);
                findCommand.Execute();
                break;

            case "search":
                if (parts.Length != 4)
                {
                    Console.WriteLine("Invalid arguments for 'search'. Expected format: 'search <StartDate> <EndDate> <CategoryName>'");
                    return;
                }
                startDate = DateTime.Parse(parts[1]);
                endDate = DateTime.Parse(parts[2]);
                string categoryName = parts[3];
                SearchBookingsCommand searchCommand = new(_bookingService, startDate, endDate, categoryName);
                searchCommand.Execute();
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}
