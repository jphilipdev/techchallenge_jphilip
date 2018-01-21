using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceDay.ApiProxies.Interfaces;
using RaceDay.DomainServices;
using RaceDay.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RaceDay.Tests
{
    [TestClass]
    public class RaceDomainServiceTests
    {
        private Mock<IRacesApiProxy> _racesApiProxy;
        private Mock<IBetsApiProxy> _betsApiProxy;
        private RaceDomainService _subject;

        #region Test Data
        private int _horseId1 = 101;
        private int _horseId2 = 102;
        private int _horseId3 = 103;
        private int _horseId4 = 104;
        private int _horseId5 = 105;
        private int _horseId6 = 106;

        private string _horseName1 = "horseName1";
        private string _horseName2 = "horseName2";
        private string _horseName3 = "horseName3";
        private string _horseName4 = "horseName4";
        private string _horseName5 = "horseName5";
        private string _horseName6 = "horseName6";

        private decimal _horseOdds1 = 1.2m;
        private decimal _horseOdds2 = 2.3m;
        private decimal _horseOdds3 = 3.4m;
        private decimal _horseOdds4 = 4.5m;
        private decimal _horseOdds5 = 5.6m;
        private decimal _horseOdds6 = 6.7m;

        private int _raceId1 = 201;
        private int _raceId2 = 202;

        private string _raceName1 = "raceName1";
        private string _raceName2 = "raceName2";

        private DateTime _raceStart1 = DateTime.Now.AddDays(1);
        private DateTime _raceStart2 = DateTime.Now.AddDays(2);

        private string _raceStatus1 = "raceStatus1";
        private string _raceStatus2 = "raceStatus2";

        private int _customerId1 = 301;
        private int _customerId2 = 302;
        private int _customerId3 = 303;

        private decimal _stake1 = 10;
        private decimal _stake2 = 20;
        private decimal _stake3 = 30;
        private decimal _stake4 = 40;
        private decimal _stake5 = 50;
        private decimal _stake6 = 60;
        #endregion Test Data

        [TestInitialize]
        public void Setup()
        {
            _racesApiProxy = new Mock<IRacesApiProxy>();
            _betsApiProxy = new Mock<IBetsApiProxy>();

            _subject = new RaceDomainService(_racesApiProxy.Object, _betsApiProxy.Object);
        }

        [TestMethod]
        public async Task Should_correctly_calculate_race_details()
        {
            // ARRANGE
            var races = Task.FromResult(CreateRaces());
            var bets = Task.FromResult(CreateBets());

            _racesApiProxy.Setup(p => p.GetRaces())
                          .Returns(races);

            _betsApiProxy.Setup(p => p.GetBets())
                         .Returns(bets);


            // ACT
            var result = await _subject.GetRaceDetails();


            // ASSERT
            _racesApiProxy.Verify();
            _betsApiProxy.Verify();

            Assert.AreEqual(2, result.Count(), "race details count");

            // assert race 1 details
            var race1 = VerifyRace(result, _raceId1, _raceStatus1, _stake1 + _stake2 + _stake3, 3);

            VerifyHorse(race1, _horseId1, 2, (_stake1 + _stake2) * _horseOdds1);
            VerifyHorse(race1, _horseId2, 1, _stake3 * _horseOdds2);
            VerifyHorse(race1, _horseId3, 0, 0);

            // assert race 2 details
            var race2 = VerifyRace(result, _raceId2, _raceStatus2, _stake4 + _stake5 + _stake6, 3);

            VerifyHorse(race2, _horseId4, 1, _stake4 * _horseOdds4);
            VerifyHorse(race2, _horseId5, 2, (_stake5 + _stake6) * _horseOdds5);
            VerifyHorse(race2, _horseId6, 0, 0);
        }

        private RaceDetails VerifyRace(IEnumerable<RaceDetails> races, int raceId, string raceStatus, decimal totalPlaced, int horsesCount)
        {
            Assert.AreEqual(1, races.Where(p => p.Race.Id == raceId).Count(), $"count of races with ID '{raceId}'");
            var race = races.Single(p => p.Race.Id == raceId);

            Assert.AreEqual(raceStatus, race.Status, $"race '{raceId}' status");
            Assert.AreEqual(totalPlaced, race.TotalPlaced, $"race '{raceId}' total placed");
            Assert.AreEqual(horsesCount, race.Horses.Count(), $"race '{raceId}' horses count");

            return race;
        }

        private void VerifyHorse(RaceDetails race, int horseId, int numberOfBets, decimal totalPotentialPayout)
        {
            Assert.AreEqual(1, race.Horses.Where(p => p.Horse.Id == horseId).Count(), $"race '{race.Race.Id}' count of horses with ID '{horseId}'");
            var horse = race.Horses.Single(p => p.Horse.Id == horseId);
            Assert.AreEqual(numberOfBets, horse.NumberOfBets, $"horse '{horseId}' number of bets");
            Assert.AreEqual(totalPotentialPayout, horse.TotalPotentialPayout, $"horse '{horseId}' total potential payout");
        }

        private IEnumerable<Race> CreateRaces()
        {
            var horse1 = CreateHorse(_horseId1, _horseName1, _horseOdds1);
            var horse2 = CreateHorse(_horseId2, _horseName2, _horseOdds2);
            var horse3 = CreateHorse(_horseId3, _horseName3, _horseOdds3);
            var horse4 = CreateHorse(_horseId4, _horseName4, _horseOdds4);
            var horse5 = CreateHorse(_horseId5, _horseName5, _horseOdds5);
            var horse6 = CreateHorse(_horseId6, _horseName6, _horseOdds6);

            var race1 = CreateRace(_raceId1, _raceName1, _raceStart1, _raceStatus1, new[] { horse1, horse2, horse3 });
            var race2 = CreateRace(_raceId2, _raceName2, _raceStart2, _raceStatus2, new[] { horse4, horse5, horse6 });

            return new[] { race1, race2 };
        }

        private Race CreateRace(int id, string name, DateTime start, string status, IEnumerable<Horse> horses)
        {
            return new Race(id, name, start, status, horses);
        }

        private Horse CreateHorse(int id, string name, decimal odds)
        {
            return new Horse(id, name, odds);
        }

        private IEnumerable<Bet> CreateBets()
        {
            // horses 1 and 5 have 2 bets
            // horses 2 and 4 have 1 bet
            // horses 3 and 6 have no bets
            var bet1 = CreateBet(_customerId1, _raceId1, _horseId1, _stake1);
            var bet2 = CreateBet(_customerId2, _raceId1, _horseId1, _stake2);
            var bet3 = CreateBet(_customerId3, _raceId1, _horseId2, _stake3);
            var bet4 = CreateBet(_customerId1, _raceId2, _horseId4, _stake4);
            var bet5 = CreateBet(_customerId2, _raceId2, _horseId5, _stake5);
            var bet6 = CreateBet(_customerId3, _raceId2, _horseId5, _stake6);

            return new[] { bet1, bet2, bet3, bet4, bet5, bet6 };
        }

        private Bet CreateBet(int customerId, int raceId, int horseId, decimal stake)
        {
            return new Bet(customerId, raceId, horseId, stake);
        }
    }
}