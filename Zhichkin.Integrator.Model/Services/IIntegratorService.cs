﻿using Zhichkin.Integrator.Model;
using System.Collections.Generic;

namespace Zhichkin.Integrator.Services
{
    public interface IIntegratorService
    {
        IList<Publisher> GetPublishers();
        int PublishChanges(Publisher publisher);
        int ProcessMessages(Publisher publisher); //Subscriber
    }
}
