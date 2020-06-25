using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_CommsChannelRepository
    {
        Trans_CommsChannel GetTrans_CommsChannel(string Id);

		IEnumerable<Trans_CommsChannel> GetAllTrans_CommsChannel();
        Trans_CommsChannel Add(Trans_CommsChannel rec);
        Trans_CommsChannel Update(Trans_CommsChannel recChanges);
        Trans_CommsChannel Delete(string id);
         
    }
}