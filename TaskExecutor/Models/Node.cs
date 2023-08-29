﻿namespace TaskExecutor.Models
{
    public class Node
    {
        public NodeRegistrationRequest NodeRegistrationRequest { get; set; }
        public NodeStatus Status { get; set; }

        public Node(NodeRegistrationRequest nodeRegistrationRequest)
        {
            NodeRegistrationRequest = nodeRegistrationRequest;
            Status = NodeStatus.Available;
        }

        public void MakeOffline()
        {
            Status = NodeStatus.Offline;
        }
    }
}