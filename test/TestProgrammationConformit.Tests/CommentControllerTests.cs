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
    public class CommentControllerTests : IDisposable
    {

        Mock<ICommentService> iCommentService;
        CommentProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;


        public CommentControllerTests()
        {
            iCommentService = new Mock<ICommentService>();
            realProfile = new CommentProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            iCommentService = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        //**************************************************
        //*
        //GET   /api/comment Unit Tests
        //*
        //**************************************************

        //TEST 1.1
        [Fact]
        public void GetAllComment_ReturnsZeroResources_WhenDBIsEmpty()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetAllComments()).Returns(GetComments(0));

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.GetAllComments();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        //TEST 1.2
        [Fact]
        public void GetAllComment_ReturnsOneResource_WhenDBHasOneResource()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetAllComments()).Returns(GetComments(1));

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.GetAllComments();

            //Assert
            var okResult = result.Result as OkObjectResult;

            var comments = okResult.Value as List<CommentReadDTO>;

            Assert.Single(comments);
        }

        //**************************************************
        //*
        //GET   /api/comment/{id} Unit Tests
        //*
        //**************************************************

        //TEST 2.1        
        [Fact]
        public void GetCommentByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetCommentById(0)).Returns(() => null);

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.GetCommentById(1);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        //TEST 2.2
        [Fact]
        public void GetCommentByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetCommentById(1)).Returns(new Comment { CommentId = 1, Description = "Mock", Date = new DateTime(), EventId = 1 });

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.GetCommentById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        //**************************************************
        //*
        //POST   /api/comment/ Unit Tests
        //*
        //**************************************************

        //TEST 3.1
        [Fact]
        public void CreateComment_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetCommentById(1)).Returns(new Comment { CommentId = 1, Description = "Mock", Date = new DateTime(), EventId = 1 });

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.CreateComment(new CommentCreateDTO { });

            //Assert
            Assert.IsType<ActionResult<CommentReadDTO>>(result);
        }

        //TEST 3.2
        [Fact]
        public void CreateComment_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetCommentById(1)).Returns(new Comment { CommentId = 1, Description = "Mock", Date = new DateTime(), EventId = 1 });

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.CreateComment(new CommentCreateDTO { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        //**************************************************
        //*
        //PUT   /api/comment/{id} Unit Tests
        //*
        //**************************************************

        //TEST 4.1
        [Fact]
        public void UpdateComment_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetCommentById(1)).Returns(new Comment { CommentId = 1, Description = "Mock", Date = new DateTime(), EventId = 1 });

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.UpdateComment(1, new CommentUpdateDTO { });

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        //TEST 4.2
        [Fact]
        public void UpdateComment_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetCommentById(0)).Returns(() => null);

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.UpdateComment(0, new CommentUpdateDTO { });

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
        public void DeleteComment_Returns200OK_WhenValidResourceIDSubmitted()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetCommentById(1)).Returns(new Comment { CommentId = 1, Description = "Mock", Date = new DateTime(), EventId = 1 });

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.DeleteComment(1);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        //TEST 6.2
        [Fact]
        public void DeleteComment_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange 
            iCommentService.Setup(serv =>
              serv.GetCommentById(0)).Returns(() => null);

            var controller = new CommentController(iCommentService.Object, mapper);

            //Act
            var result = controller.DeleteComment(0);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }


        //**************************************************
        //*
        //Private Support Methods
        //*
        //**************************************************

        private List<Comment> GetComments(int num)
        {
            var comments = new List<Comment>();
            if (num > 0)
            {
                comments.Add(new Comment
                {
                    CommentId = 0,
                    Description = "Method to upload file",
                    Date = new DateTime(),
                    EventId = 1
                });
            }
            return comments;
        }
    }
}
