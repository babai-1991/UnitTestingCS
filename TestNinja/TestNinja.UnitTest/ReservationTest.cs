using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestClass]
    public class ReservationTest
    {
        [TestMethod]
        public void CanBeCancelledBy_IsAdmin__UserIsAdmin_Returnstrue()
        {
            //arrange
            var reservation = new Reservation();
            var user = new User() { IsAdmin = true };

            //act
            var result = reservation.CanBeCancelledBy(user);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_SameUserCancellingReservation_ReturnsTrue()
        {
            //arrange
            var reservation = new Reservation();
            var user = new User() {IsAdmin = false};
            reservation.MadeBy = user;

            //act
            var result = reservation.CanBeCancelledBy(user);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            //arrange
            var reservation = new Reservation();
            var reservationUser = new User();
            reservation.MadeBy = reservationUser;
            var cancellingUser = new User();
            //act
            var result = reservation.CanBeCancelledBy(cancellingUser);

            //assert
            Assert.IsFalse(result);
        }
    }
}
