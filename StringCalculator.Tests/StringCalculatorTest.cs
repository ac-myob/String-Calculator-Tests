using System;
using Xunit;

namespace StringCalculator.Tests;

public class StringCalculatorTest
// Nameing: method_doesThis_underCircumstances
// Code arrangement: Arrange, Act, Assert
{
    [Fact]
    public void Add_ReturnsZero_WithEmptyString() {
        var stringCalculator = new StringCalculator();
        var expected = 0;

        var result = stringCalculator.Add("");
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("3", 3)]
    public void Add_ReturnsNumber_WithNumberAsString(string str, int expected) {
        var stringCalculator = new StringCalculator();

        var result = stringCalculator.Add(str);
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("3,5", 8)]

    public void Add_ReturnsSumOfNumbers_WithNumbersSeparatedByComma(string str, int expected) {
        var stringCalculator = new StringCalculator();

        var result = stringCalculator.Add(str);
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("3,5,3,9", 20)]
    public void Add_ReturnsSumOfNumbers_WithNumbersSeparatedByMultipleCommas(string str, int expected) {
        var stringCalculator = new StringCalculator();

        var result = stringCalculator.Add(str);
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2\n3", 6)]
    [InlineData("3\n5\n3,9", 20)]
    public void Add_ReturnsSumOfNumbers_WithNumbersSeparatedByCommasAndNewlines(string str, int expected) {
        var stringCalculator = new StringCalculator();

        var result = stringCalculator.Add(str);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_ReturnsSumOfNumbers_WithCustomSingleCharacterDelimiter() {
        var stringCalculator = new StringCalculator();
        var expected = 3;

        var result = stringCalculator.Add("//;\n1;2");
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_ThrowsNegativeNumberException_WithNegativeNumbers() {
        var stringCalculator = new StringCalculator();

        Assert.Throws<NegativeNumberException>(()=>stringCalculator.Add("-1,2,-3"));
    }

    [Fact]
    public void Add_ReturnsSumOfNumbersThatAreLessThan1000_WithNumbersOver1000() {
        var stringCalculator = new StringCalculator();
        var expected = 2;

        var result = stringCalculator.Add("1000,1001,2");
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_ReturnsSumOfNumbers_WithCustomMultiCharacterDelimiter() {
        var stringCalculator = new StringCalculator();
        var expected = 6;

        var result = stringCalculator.Add("//[***]\n1***2***3");
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_ReturnsSumOfNumbers_WithMultipleCustomSingleCharacterDelimiters() {
        var stringCalculator = new StringCalculator();
        var expected = 6;

        var result = stringCalculator.Add("//[*][%]\n1*2%3");
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_ReturnsSumOfNumbers_WithMultipleCustomMultiCharacterDelimiters() {
        var stringCalculator = new StringCalculator();
        var expected = 10;

        var result = stringCalculator.Add("//[***][#][%]\n1***2#3%4");
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Add_ReturnsSumOfNumbers_WithMultipleCustomMultiCharacterDelimitersThatIncludeNumbers() {
        var stringCalculator = new StringCalculator();
        var expected = 6;

        var result = stringCalculator.Add("//[*1*][%]\n1*1*2%3");
        
        Assert.Equal(expected, result);
    }

}