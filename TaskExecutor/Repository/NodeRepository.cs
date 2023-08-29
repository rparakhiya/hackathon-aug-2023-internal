﻿using TaskExecutor.Models;

namespace TaskExecutor.Repository
{
    public class NodeRepository
    {
        private static NodeRepository _instance;
        private readonly List<Node> _nodes;

        private NodeRepository()
        {
            _nodes = new List<Node>();
        }

        public static NodeRepository GetInstance() 
        { 
            if(_instance == null)
            {
                _instance = new NodeRepository();
            }
            return _instance; 
        }

        public void AddNode(Node node)
        {
            _nodes.Add(node);
        }

        public Node RemoveNode(string name)
        {
            Node nodeToRemove = _nodes.FirstOrDefault(_ => _.NodeRegistrationRequest.Name.Equals(name));
            if(nodeToRemove != null)
            {
                _nodes.Remove(nodeToRemove);
                return nodeToRemove;
            }

            throw new InvalidOperationException("Worker with the Name: " + name + " Not Found");
        }

        public void MakeNodeOffline(string name)
        {
            Node nodeToMakeOffline = _nodes.FirstOrDefault(_ => _.NodeRegistrationRequest.Name.Equals(name));
            if (nodeToMakeOffline != null)
            {
                nodeToMakeOffline.MakeOffline();
            }

            throw new InvalidOperationException("Worker with the Name: " + name + " Not Found");
        }

        public List<Node> GetAllNodes()
        {
            return _nodes;
        }

        public List<Node> GetAllActiveNodes()
        {
            return _nodes.Where(_ => _.Status == NodeStatus.Available || _.Status == NodeStatus.Busy).ToList();
        }

        public Node GetAvailableNode()
        {
            return _nodes.FirstOrDefault(_ => _.Status == NodeStatus.Available);
        }
    }
}