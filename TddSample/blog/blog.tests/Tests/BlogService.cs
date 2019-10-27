using System.Collections.Generic;
using blog.api.Controllers;
using blog.api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace blog.tests.Tests
{
    public class BlogService
    {
        /// <summary>
        /// Entry Point for My API
        /// </summary>
        private readonly BlogController _blogController;

        /// <summary>
        /// List of Mock Itens
        /// </summary>
        private readonly Mock<List<Post>> _mockPostsList;

        public BlogService()
        {
            _mockPostsList = new Mock<List<Post>>();
            _blogController = new BlogController(_mockPostsList.Object);
        }

        [Fact]
        public void ShouldBeReturnListOfPosts()
        {
            var mockPost = new List<Post>
            {
                new Post{Title = "Tdd One"},
                new Post{Title = "Tdd Two"}
            };

            _mockPostsList.Object.AddRange(mockPost);

            //act
            var result = _blogController.Get();

            //assert
            var model = Assert.IsAssignableFrom<ActionResult<List<Post>>>(result);
            Assert.Equal(2, model.Value.Count);
        }

    }
}