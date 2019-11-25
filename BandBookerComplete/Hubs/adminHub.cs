using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandBooker.Hubs
{
    public class AdminHub : Hub
    {
        public async Task SyncMusicianBio(int MusicianId, string Bio)
        {
            await Clients.Others.SendAsync("ReceiveSyncMusicianBio",
                MusicianId, Bio);
        }
    }
}