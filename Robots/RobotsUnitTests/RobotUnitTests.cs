using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robots;

namespace RobotsUnitTests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void BeCorrectForShooterAiWithShooterMover()
        {
            var robot = Robot.Create<IShooterMoveCommand>(new ShooterAI(), new ShooterMover());
            var result = robot.Start(5).ToList();

            string shouldHide(int step) => step % 3 == 0 ? "YES" : "NO";
            string shouldShoot(int step) => step % 5 ==0 ? "YES" : "NO";

            var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z * 2}, {z * 3}, FIRE {shouldShoot(z)}, USE COVER {shouldHide(z)}").ToList();
            CollectionAssert.AreEqual(dueResult, result);
        }

        [TestMethod]
        public void BeCorrectForShooterAiWithStandardMover()
        {
            var robot = Robot.Create<IShooterMoveCommand>(new ShooterAI(), new Mover());
            var result = robot.Start(5).ToList();
            var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z * 2}, {z * 3}").ToList();
            CollectionAssert.AreEqual(dueResult, result);
        }

        [TestMethod]
        public void BeCorrectForBuilder()
        {
            var robot = Robot.Create<IMoveCommand>(new BuilderAI(), new Mover());
            var result = robot.Start(5).ToList();
            var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z}, {z}").ToList();
            CollectionAssert.AreEqual(dueResult, result);
        }

        //[TestMethod]
        //public void BeCorrectForGuardian()
        //{
        //    var robot = Robot.Create<IGuardianMoveCommand>(new GuardianAI(), new GuardianMover());
        //    var result = robot.Start(5).ToList();
        //    var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z * 0.5}, {z * 0.5}, GUARD {(z % 2 == 0 ? "YES" : "NO")}").ToList();
        //    CollectionAssert.AreEqual(dueResult, result);
        //}
    }
}
