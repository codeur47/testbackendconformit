using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Tests
{
    public class EventTests : IDisposable
    {

        Event testEvent;

        public EventTests()
        {
            testEvent = new Event
            {
                Title = "Formmsmss",
                Description = "Dnndjnfjnjed",
                EventOwner = "Yoro Ange Carmel"
            };
        }

        public void Dispose()
        {
            testEvent = null;
        }

        [Fact]
        public void CanChangeTitle()
        {
            //Arrange
            
            //Act
            testEvent.Title = "Execute Unit Tests";

            //Assert
            Assert.Equal("Execute Unit Tests", testEvent.Title);
        }

    }
}
