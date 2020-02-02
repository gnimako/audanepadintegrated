using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_CommsChannelRepository
    {
        LkUp_CommsChannel GetCommsChannel (int Id);

        LkUp_CommsChannel GetCommsChannelByName(string name);
		IEnumerable<LkUp_CommsChannel> GetAllCommsChannel();
        LkUp_CommsChannel Add(LkUp_CommsChannel rec);
        LkUp_CommsChannel Update(LkUp_CommsChannel recChanges);
        LkUp_CommsChannel Delete(int id);
         
    }
}