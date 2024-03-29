using dmitry_efimov_kt_31_20.Models;
using System.Text.RegularExpressions;
using Group = dmitry_efimov_kt_31_20.Models.Group;

namespace dmitry_edimov_kt_31_20.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3120_True()
        {
            //arrange
            var testGroup = new Group
            {
                GroupName = "KT-31-20"
            };

            //act
            var result = testGroup.IsValidGroupName();

            //assert
            Assert.True(result);
        }
    }
}