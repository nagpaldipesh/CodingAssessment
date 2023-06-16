using System;
using System.Linq;
using CodingAssessment.Refactor;
using ReFactor.Constants;
using ReFactor.Models;
using Tests.TestHelpers;
using Xunit;

namespace Tests
{
    public class UserServiceTests
    {
        private UserService _userService;

        public UserServiceTests() {
            _userService = new UserService();
        }

        [Fact]
        public void GetUsers_ShouldReturnEmptyList_WhenZeroIsPassed()
        {
            var result = _userService.GetUsers(numberOfUsers: 0);

            Assert.Empty(result);
        }

        [Fact]
        public void GetUsers_ShouldReturnUserList()
        {
            var result = _userService.GetUsers(numberOfUsers: 5);

            Assert.Equal(5, result.Count);

            foreach (var user in result) {
                Assert.NotNull(user);
                Assert.NotEmpty(user.Name);
            }
        }

        [Fact]
        public void GetUserName_ShouldThrowsNullReferenceException_WhenUserIsNull() 
        {
            string lastName = "Nagpal";

            Assert.Throws<NullReferenceException>(() =>_userService.GetUserName(user: null, lastName));
        }

        [Fact]
        public void GetUserName_ShouldReturnName_WhenLastNameContainsTest() 
        {
            var user = UserHelper.GetUser();
            string lastName = "Nagpaltest";

            var userName = _userService.GetUserName(user, lastName);
            Assert.Equal(user.Name, userName);
        }

        [Fact]
        public void GetUserName_ShouldReturnCombinedName_WhenUserNameContainsTestButCasingIsDifferent() 
        {
            var user = UserHelper.GetUser();
            string lastName = "NagpalTest";

            string expectedName = user.Name + " " + lastName;
            var userName = _userService.GetUserName(user, lastName);
            Assert.Equal(expectedName, userName);
        }

        [Fact]
        public void GetUserName_ShouldReturnSubstringOfCombinedName_WhenCombinedNameLengthIsGreaterThan255() 
        {
            var user = UserHelper.GetUser();
            string lastName = UserHelper.GenerateRandomString(255);

            string expectedName = (user.Name + " " + lastName).Substring(0, 255); ;
            var userName = _userService.GetUserName(user, lastName);
            Assert.Equal(expectedName, userName);
            Assert.Equal(255, userName.Length);
        }

        [Fact]
        public void GetUsersByName_ShouldReturnEmptyList_WhenUserListIsEmpty() {
            string name = AppConstants.Bob;

            var result = _userService.GetUsersByName(name, false);
            Assert.Empty(result);
        }
        
        [Fact]
        public void GetUsersByName_ShouldReturnUserList_WhenUserAgeIsLessThanThirty() {
            // Adding 10 users into user list
            var users = _userService.GetUsers(numberOfUsers: 10);
            Assert.NotEmpty(users);
            Assert.Equal(10, users.Count);

            string name = AppConstants.Bob;

            var expectedCount = users.Where(cond => cond.Name == name).Count();

            var result = _userService.GetUsersByName(name, isUserOlderThanThirty: false);
            Assert.NotEmpty(result);
            Assert.Equal(expectedCount, result.Count());
        }
        
        [Fact]
        public void GetUsersByName_ShouldReturnEmptyUserList_WhenUserNameIsNotPresent() {
            // Adding 10 users into user list
            var users = _userService.GetUsers(numberOfUsers: 10);
            Assert.NotEmpty(users);
            Assert.Equal(10, users.Count);

            string name = AppConstants.Betty;
            DateTime thirtyYearsAgo = DateTime.Now.Subtract(new TimeSpan(30 * 356));

            var expectedCount = users.Where(x => x.Name == name && x.DOB >= thirtyYearsAgo).Count();

            var result = _userService.GetUsersByName(name, isUserOlderThanThirty: true);
            Assert.Empty(result);
            Assert.Equal(expectedCount, result.Count());
        }
        
        [Fact]
        public void GetUsersByName_ShouldReturnUserList() {
            // Adding 10 users into user list
            var users = _userService.GetUsers(numberOfUsers: 10);
            Assert.NotEmpty(users);
            Assert.Equal(10, users.Count);

            string name = AppConstants.Bob;
            DateTime thirtyYearsAgo = DateTime.Now.Subtract(new TimeSpan(30 * 356));

            var expectedCount = users.Where(x => x.Name == name && x.DOB >= thirtyYearsAgo).Count();

            var result = _userService.GetUsersByName(name, isUserOlderThanThirty: true);
            Assert.Equal(expectedCount, result.Count());
        }
    }
}
