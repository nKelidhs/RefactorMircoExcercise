using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TDDMicroExercises.TurnTicketDispenser;

namespace TDDMicroExercisesTests.TicketDispenserSystem.Tests
{
    [TestClass]
    public class TicketDispenserTests
    {

        [TestMethod]
        public void GetTurnTicket_Turn_numbers_from_single_Dispenser_must_be_subsequent()
        {
            // Arrange
            var dispenser = new TicketDispenser();

            // Act
            var ticket1 = dispenser.GetTurnTicket();

            var ticket2 = dispenser.GetTurnTicket();
            var ticket2ExpectedTurnNumber = ticket1.TurnNumber + 1;
            var ticket3 = dispenser.GetTurnTicket();
            var ticket3ExpectedTurnNumber = ticket2ExpectedTurnNumber + 1;
            var ticket4 = dispenser.GetTurnTicket();
            var ticket4ExpectedTurnNumber = ticket3ExpectedTurnNumber + 1;

            // Assert
            Assert.IsTrue(ticket2.TurnNumber == ticket2ExpectedTurnNumber);
            Assert.IsTrue(ticket3.TurnNumber == ticket3ExpectedTurnNumber);
            Assert.IsTrue(ticket4.TurnNumber == ticket4ExpectedTurnNumber);
        }

        [TestMethod]
        public void GetTurnTicket_Turn_numbers_from_multiple_Dispensers_must_be_subsequent()
        {
            // Arrange
            var dispenser1 = new TicketDispenser();
            var dispenser2 = new TicketDispenser();
            var dispenser3 = new TicketDispenser();
            var dispenser4 = new TicketDispenser();

            // Act
            var ticket1 = dispenser1.GetTurnTicket();

            var ticket2 = dispenser2.GetTurnTicket();
            var ticket2ExpectedTurnNumber = ticket1.TurnNumber + 1;
            var ticket3 = dispenser3.GetTurnTicket();
            var ticket3ExpectedTurnNumber = ticket2ExpectedTurnNumber + 1;
            var ticket4 = dispenser4.GetTurnTicket();
            var ticket4ExpectedTurnNumber = ticket3ExpectedTurnNumber + 1;


            // Assert
            Assert.IsTrue(ticket2.TurnNumber == ticket2ExpectedTurnNumber);
            Assert.IsTrue(ticket3.TurnNumber == ticket3ExpectedTurnNumber);
            Assert.IsTrue(ticket4.TurnNumber == ticket4ExpectedTurnNumber);
        }

        [TestMethod]
        public void GetTurnTicket_Turn_numbers_must_be_unique()
        {
            // Arrange
            var dispenser1 = new TicketDispenser();
            var dispenser2 = new TicketDispenser();
            var dispenser3 = new TicketDispenser();
            var tickets = new List<TurnTicket>();
            var diffChecker = new HashSet<int>();

            // Act
            for (int i = 0; i <= 20; i++)
            {
                tickets.Add(dispenser1.GetTurnTicket());
                tickets.Add(dispenser2.GetTurnTicket());
                tickets.Add(dispenser3.GetTurnTicket());
            }

            // Assert
            Assert.IsTrue(tickets.Select(x => x.TurnNumber).All(number => diffChecker.Add(number)));
        }
    }
}
