using System;
using Xunit;

namespace Logic
{
    public class ActiveShiftTests
    {
        [Fact]
        public void IsActiveShift_PM_To_AM_True()
        {
            ActiveShift shift = new ActiveShift();

            bool expected = true;
            DateTime date = new DateTime(2020, 7, 22, 6, 0, 0);
            bool actual = shift.IsActiveShift(date, "10 PM", "6.00 AM");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsActiveShift_PM_To_AM_False()
        {
            ActiveShift shift = new ActiveShift();

            bool expected = false;
            DateTime date = new DateTime(2020, 7, 22, 7, 0, 0);
            bool actual = shift.IsActiveShift(date, "10 PM", "6.00 AM");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsActiveShift_AM_To_PM_False()
        {
            ActiveShift shift = new ActiveShift();

            bool expected = false;
            DateTime date = new DateTime(2020, 7, 22, 7, 0, 0);
            bool actual = shift.IsActiveShift(date, "9 AM", "6.30 PM");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsActiveShift_AM_To_PM_True()
        {
            ActiveShift shift = new ActiveShift();

            bool expected = true;
            DateTime date = new DateTime(2020, 7, 22, 9, 1, 0);
            bool actual = shift.IsActiveShift(date, "9 AM", "6.30 PM");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsActiveShift_PM_To_PM_True()
        {
            ActiveShift shift = new ActiveShift();

            bool expected = true;
            DateTime date = new DateTime(2020, 7, 22, 22, 0, 0);
            bool actual = shift.IsActiveShift(date, "6 PM", "11.59 PM");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsActiveShift_PM_To_PM_Fale()
        {
            ActiveShift shift = new ActiveShift();

            bool expected = false;
            DateTime date = new DateTime(2020, 7, 22, 16, 59, 0);
            bool actual = shift.IsActiveShift(date, "6 PM", "11.59 PM");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsActiveShift_AM_To_AM_True()
        {
            ActiveShift shift = new ActiveShift();

            bool expected = true;
            DateTime date = new DateTime(2020, 7, 22, 9, 1, 0);
            bool actual = shift.IsActiveShift(date, "9 AM", "12.00 AM");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsActiveShift_AM_To_AM_False()
        {
            ActiveShift shift = new ActiveShift();

            bool expected = false;
            DateTime date = new DateTime(2020, 7, 22, 8, 1, 0);
            bool actual = shift.IsActiveShift(date, "9 AM", "12.00 AM");

            Assert.Equal(expected, actual);
        }
    }
}
