using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using TicketServer;

namespace Client
{
    
    class Program
    {

        static void Main(string[] args)
        {
            try    
            {
                HttpChannel httpChannel = new HttpChannel();
                ChannelServices.RegisterChannel(httpChannel);

                Type requiredType = typeof(MovieTicketInterface);

                MovieTicketInterface remoteObject = (MovieTicketInterface) Activator.GetObject(requiredType,
                    "Http://localhost:9998/MovieTicketBooking");

                Console.WriteLine(remoteObject.GetTicketStatus("Ticket No: 3344"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    }

