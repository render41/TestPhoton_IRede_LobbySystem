using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace ManagerService.RoomListing
{
    public class RoomListing : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform content;
        [SerializeField] private RoomItemList roomItemPrefab;

        private readonly List<RoomItemList> _roomItemsList = new List<RoomItemList>();
        private float _timeBetweenUpdates = 1.5f;
        private float _nextUpdateTime;
        

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            if (Time.time >= _nextUpdateTime)
            {
                foreach (var room in roomList)
                {
                    if (room.RemovedFromList)
                        ClearRoomItems(room);
                    else
                        AddRooms(room);
                }

                _nextUpdateTime = Time.time + _timeBetweenUpdates;
            }

        }

        private void ClearRoomItems(RoomInfo room)
        {
            var index = _roomItemsList.FindIndex(x => x.RoomInfo.Name == room.Name);
            if (index != -1)
            {
                Destroy(_roomItemsList[index].gameObject);
                _roomItemsList.RemoveAt(index);
            }
            _roomItemsList.Clear();
        }

        private void AddRooms(RoomInfo room)
        {
            var newRoom = Instantiate(roomItemPrefab, content);
            if (newRoom == null) return;
            newRoom.SetRoomName(room);
            _roomItemsList.Add(newRoom);
        }
    }
}