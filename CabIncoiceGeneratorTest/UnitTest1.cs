using NUnit.Framework;
using CabInvoiceGenerator;

namespace CabIncoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = null;
        }

        //UC-1
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            Assert.AreEqual(fare, expected);
        }

        //UC-2
        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }

        //UC-3
        [Test]
        public void GivenMultipleRidesShouldReturnEnhancedInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);

            Assert.AreEqual(expectedSummary, summary);
        }

        //UC-4
        [Test]
        public void GivenUserIdShouldReturnInvoiceService()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            invoiceGenerator.AddRides("ktr", rides);

            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceSummary("ktr");

            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30, 15);

            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

        //UC-5
        [Test]
        public void GivenPremiumRidesReturnInvoiceService()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            invoiceGenerator.AddRides("ktr", rides);

            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceSummary("ktr");

            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60);

            Assert.AreEqual(expectedSummary, invoiceSummary);
        }

    }
}