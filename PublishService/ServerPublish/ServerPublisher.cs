using Core.LongService;
using Microsoft.AspNetCore.SignalR;
using PublishService.ServerPublish.Repo.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PublishService.ServerPublish
{
    public class ServerPublisher : LongServiceAbstract, IDisposable
    {
        private Timer CollectionTimer { get; }
        private ServerRuntimeRepostory ServerRuntimeRepostory { get; }
        private IHubContext<ServerPublishHub> HubContext { get; }
        public ServerPublisher(ServerRuntimeRepostory serverRuntimeRepostory, IHubContext<ServerPublishHub> hubContext)
        {
            ServerRuntimeRepostory = serverRuntimeRepostory;
            HubContext = hubContext;
            CollectionTimer = new Timer(LoopTask, null, 0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);
        }

        private void LoopTask(object o)
        {
            Task.Run(async () =>
            {
                var info = await ServerRuntimeRepostory.GetHomeInfo();
                _ = HubContext.Clients.All.SendAsync("serverruntimeinfo", info);
            });
        }

        public override Task Stop()
        {
            CollectionTimer.Dispose();
            return base.Stop();
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
