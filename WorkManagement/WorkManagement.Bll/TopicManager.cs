using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkManagement.Entity.Dtos;
using WorkManagement.Entity.Models;
using WorkManagement.Interface;

namespace WorkManagement.Bll
{
    public class TopicManager : GenericManager<Topic, DtoTopic>, ITopicService
    {
        public TopicManager(IServiceProvider service) : base(service)
        {
        }
    }
}
