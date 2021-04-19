using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AutoMapper;
using TestProgrammationConformit.Services;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Controllers;
using TestProgrammationConformit.Profiles;
using Microsoft.AspNetCore.Mvc;
using TestProgrammationConformit.Dtos;


namespace TestProgrammationConformit.Tests
{
    public class EventControllerTests : IDisposable
    {

        Mock<IEventService> mockEventService;
        EventProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public EventControllerTests()
        {
            mockEventService = new Mock<IEventService>();
            realProfile = new EventProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }


        public void Dispose()
        {
            mockEventService = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }



        //**************************************************
        //*
        //GET   /api/event Unit Tests
        //*
        //**************************************************

        //TEST 1.1
        [Fact]
        public void GetAllEvents_ReturnsZeroResources_WhenDBIsEmpty()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetAllEvents()).Returns(GetEvents(0));

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.GetAllEvents();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        //TEST 1.2
        [Fact]
        public void GetAllEvents_ReturnsOneResource_WhenDBHasOneResource()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetAllEvents()).Returns(GetEvents(1));

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.GetAllEvents();

            //Assert
            var okResult = result.Result as OkObjectResult;

            var events = okResult.Value as List<EventReadDTO>;

            Assert.Single(events);
        }

        //TEST 1.3
        [Fact]
        public void GetAllEvents_Returns200OK_WhenDBHasOneResource()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetAllEvents()).Returns(GetEvents(1));

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.GetAllEvents();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        //TEST 1.4
        [Fact]
        public void GetAllEvents_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetAllEvents()).Returns(GetEvents(1));

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.GetAllEvents();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<EventReadDTO>>>(result);
        }

        //**************************************************
        //*
        //GET   /api/commands/{id} Unit Tests
        //*
        //**************************************************

        //TEST 2.1        
        [Fact]
        public void GetEventByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(0)).Returns(() => null);

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.GetEventById(1);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        //TEST 2.2
        [Fact]
        public void GetEventByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(1)).Returns(new Event { EventId = 1, Title = "mock", Description = "Mock", EventOwner = "Mock" });

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.GetEventById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        //TEST 2.3
        [Fact]
        public void GetEventByID_ReturnsCorrectResouceType_WhenValidIDProvided()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(1)).Returns(new Event { EventId = 1, Title = "mock", Description = "Mock", EventOwner = "Mock"  });

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.GetEventById(1);

            //Assert
            Assert.IsType<ActionResult<EventReadDTO>>(result);
        }

        //**************************************************
        //*
        //POST   /api/event/ Unit Tests
        //*
        //**************************************************

        //TEST 3.1
        [Fact]
        public void CreateEvent_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(1)).Returns(new Event { EventId = 1, Title = "mock", Description = "Mock", EventOwner = "Mock" });

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.CreateEvent(new EventCreateDTO { });

            //Assert
            Assert.IsType<ActionResult<EventReadDTO>>(result);
        }

        //TEST 3.2
        [Fact]
        public void CreateEvent_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(1)).Returns(new Event { EventId = 1, Title = "mock", Description = "Mock", EventOwner = "Mock" });

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.CreateEvent(new EventCreateDTO { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }


        //**************************************************
        //*
        //PUT   /api/event/{id} Unit Tests
        //*
        //**************************************************

        //TEST 4.1
        [Fact]
        public void UpdateEvent_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(1)).Returns(new Event { EventId = 1, Title = "mock", Description = "Mock", EventOwner = "Mock" });

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.UpdateEvent(1, new EventUpdateDTO { });

            //Assert
            Assert.IsType<NoContentResult>(result);
        }


        //TEST 4.2
        [Fact]
        public void UpdateEvent_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(0)).Returns(() => null);

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.UpdateEvent(0, new EventUpdateDTO { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }


        //**************************************************
        //*
        //DELETE   /api/event/{id} Unit Tests
        //*
        //**************************************************

        //TEST 6.1
        [Fact]
        public void DeleteEvent_Returns200OK_WhenValidResourceIDSubmitted()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(1)).Returns(new Event { EventId = 1, Title = "mock", Description = "Mock", EventOwner = "Mock" });

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.DeleteEvent(1);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        //TEST 6.2
        [Fact]
        public void DeleteEvent_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange 
            mockEventService.Setup(serv =>
              serv.GetEventById(0)).Returns(() => null);

            var controller = new EventController(mockEventService.Object, mapper);

            //Act
            var result = controller.DeleteEvent(0);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }

        //**************************************************
        //*
        //Private Support Methods
        //*
        //**************************************************

        private List<Event> GetEvents(int num)
        {
            var events = new List<Event>();
            if(num > 0)
            {
                events.Add(new Event
                {
                    EventId = 0,
                    Title = "How to upload file",
                    Description = "Method to upload file",
                    EventOwner = "Ange Carmel YORO"
                });
            }
            return events;
        }
    }
}
