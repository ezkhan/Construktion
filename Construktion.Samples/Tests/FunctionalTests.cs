﻿namespace Construktion.Samples.Tests
{
    using Entities;
    using FakeItEasy;
    using Shouldly;
    using Xunit;
    using static TestDSL;

    public class FunctionalTests
    {
        [Theory, ConstruktionData]
        public void should_register_service(Service service)
        {
            service.ShouldBeOfType<TestService>();
        }

        [Theory, ConstruktionData]
        public void should_use_fake_builder(Agent agent, AgentService fakeAgentService, TeamManager teamManager)
        {
            Insert(agent);
            A.CallTo(() => fakeAgentService.CallAgent(agent.Id)).Returns(true);

            teamManager.Contact(agent);

            agent.ContactedByTeam.ShouldBeTrue();
        }

        [Theory, ConstruktionData]
        public void should_omit_enumerables(PlayerBag playerBag)
        {
            playerBag.ShouldNotBeNull();
            playerBag.Players.ShouldBeNull();
        }

        [Theory, ConstruktionData]
        public void bool_properties_should_be_false(Agent agent)
        {
            agent.ContactedByTeam.ShouldBeFalse();
        }

        [Theory, ConstruktionData]
        public void but_IsActive_properties_should_be_true(PlayerBag playerBag)
        {
            playerBag.IsActive.ShouldBeTrue();
        }

        [Theory, ConstruktionData]
        public void should_be_constructed_from_exit_blueprint(Foo foo)
        {
            foo.Id.ShouldBe(0);
            foo.Name.ShouldBe("Ping");
        }
    }
}