using LXP.Api.Controllers;
using LXP.Common.ViewModels;
using Moq;
using NUnit.Framework; // Make sure to include the correct attribute namespace
using System.Collections.Generic;
using System.Threading.Tasks;
using LXP.Core.IServices;

namespace LXP.Api.Tests
{
    [TestFixture] // This attribute is necessary for NUnit to recognize the test class
    public class GetMaterialControllerNUnit
    {
        private Mock<IMaterialServices> _mockMaterialService;
        private MaterialController _materialController;
        private string _topicId;
        private string _materialTypeId;
        private List<MaterialListViewModel> _materialList;

        [SetUp]
        public void SetUp()
        {
            _mockMaterialService = new Mock<IMaterialServices>();
            _materialController = new MaterialController(_mockMaterialService.Object);
            _topicId = "3cf22229-722b-4413-9879-dcdc51ff990e";
            _materialTypeId = "0649d37a-b2fa-461e-b129-df454a9cce7f";
            _materialList = new List<MaterialListViewModel>
            {

                //materialId = "3fbdef27-4588-43a8-aee4-70946f899dfd",
                //topicName = "second topoic",
                //materialType = "PDF",
                //name = "html-2",
                //filePath = "http://localhost:5199/wwwroot/CourseMaterial/06dfcfd9-7069-466f-9baa-15b2907a921b_Cloud Assessment.pdf",
                //duration = 1,
                //isActive = true,
                //isAvailable = true,
                //createdBy = "f",
                //createdAt = "2024-05-20T11:54:21",
                //modifiedBy = null,
                //modifiedAt = ""

            };

            _mockMaterialService.Setup(service => service.GetAllMaterialDetailsByTopicAndType(_topicId, _materialTypeId))
                                .ReturnsAsync(_materialList);
        }

        [Test]
        public async Task GetAllMaterialDetailsByTopicAndMaterialType_ReturnsListOfMaterialListViewModel()
        {
            // Act
            var result = await _materialController.GetAllMaterialDetailsByTopicAndMaterialType(_topicId, _materialTypeId);

            // Assert
            Assert.IsInstanceOf<List<MaterialListViewModel>>(result);
            Assert.AreEqual(_materialList.Count, result.Count);
        }
    }
}
