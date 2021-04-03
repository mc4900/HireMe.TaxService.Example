using FluentAssertions;
using HireMe.Domain.Exceptions;
using HireMe.Domain.ValueObjects;
using NUnit.Framework;

namespace HireMe.Domain.UnitTests.ValueObjects
{
    public class ZipCodeTests
    {
        [Test]
        public void ZipCodeMustBe5or5plus4Format()
        {
            var testZip1 = "8";  //should fail
            var testZip2 = "88";  //should fail
            var testZip3 = "888";  //should fail
            var testZip4 = "8888"; //should fail
            var testZip5 = "88888"; // should pass
            var testZip6 = "888888";  //should fail
            var testZip7 = "88888-8";  //should fail
            var testZip8 = "88888-8888"; //should pass
            var testZip9 = "88888-88888"; //should fail


            FluentActions.Invoking(() => new ZipCode(testZip1)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip2)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip3)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip4)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip6)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip7)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip9)).Should().Throw<InvalideZipCodeExcption>();

            var testZip5Pass = new ZipCode(testZip5);
            var testZip8Pass = new ZipCode(testZip8);


            Assert.IsTrue(testZip8Pass.Value == testZip8);
            Assert.IsTrue(testZip5Pass.Value == testZip5);

        }

        [Test]
        public void ZipCodeCannotContainNonNumericExceptDashAt6thPosition()
        {
            var testZip1 = "aaaaa-8888";
            var testZip2 = "88888-aaaa";
            var testZip3 = "8888888888";
            var testZip4 = "88888_8888";
            var testZip5 = "88888a8888";
            var testZip6 = "8888a";
            var testZip7 = "a8888";
            var testZip8 = "8a888";
            var testZip9 = "88a88";
            var testZip10 = "888a8";
            var testZip11 = "88888-a888";
            var testZip12 = "88888-8a88";
            var testZip13 = "88888-88a8";
            var testZip14 = "88888-888a";

            FluentActions.Invoking(() => new ZipCode(testZip1)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip2)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip3)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip4)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip5)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip6)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip7)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip8)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip9)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip10)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip11)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip12)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip13)).Should().Throw<InvalideZipCodeExcption>();
            FluentActions.Invoking(() => new ZipCode(testZip14)).Should().Throw<InvalideZipCodeExcption>();

        }
    }
}
