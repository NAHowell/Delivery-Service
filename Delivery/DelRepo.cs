namespace _Delivery
{
    public class DelRepo
    {

        private List<DeliveryContent> _DelList = new List<DeliveryContent>();

        public void AddContentToList(DeliveryContent content)
        {
            _DelList.Add(content);
        }
        public List<DeliveryContent> GetContent()
        {
            return _DelList;
        }
        public bool UpdateContent(string originalId, DeliveryContent newContent)
        {
            DeliveryContent oldContent = GetContentById(originalId);

            if (oldContent != null)
            {
                oldContent.OrderDate = newContent.OrderDate;
                oldContent.Status = newContent.Status;
                oldContent.ItemNumber = newContent.ItemNumber;
                oldContent.Quantity = newContent.Quantity;
                oldContent.Id = newContent.Id;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveContent(string id)
        {
            DeliveryContent content = GetContentById(id);
            if (content == null)
            {
                return false; 
            }
            int initialCount = _DelList.Count;
            _DelList.Remove(content);
            if (initialCount > _DelList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public DeliveryContent GetContentById(string id)
        {
            foreach (DeliveryContent content in _DelList)
            {
                if (content.Id.ToLower() == id.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
    }
}

