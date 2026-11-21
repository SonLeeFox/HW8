using System;
using System.Collections.Generic;

namespace Solid1
{
    // Порушено принцип єдиної відповідальності (SRP): клас Order поєднував бізнес-логіку замовлення, роботу з БД та відображення.
    // Вирішення: розділено обов'язки між класами Order, OrderRepository та OrderViewer.
    class Item
    {
    }

    class Order
    {
        private List<Item> itemList = new List<Item>();

        internal List<Item> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        public void CalculateTotalSum() {/*...*/}
        public List<Item> GetItems() { return itemList; }
        public int GetItemCount() { return itemList.Count; }
        public void AddItem(Item item) { itemList.Add(item); }
        public void DeleteItem(Item item) { itemList.Remove(item); }
    }

    class OrderRepository
    {
        public Order Load(int orderId) { return new Order(); }
        public void Save(Order order) {/*...*/}
        public void Update(Order order) {/*...*/}
        public void Delete(Order order) {/*...*/}
    }

    class OrderViewer
    {
        public void PrintOrder(Order order) {/*...*/}
        public void ShowOrder(Order order) {/*...*/}
    }

    class Program
    {
        static void Main()
        {
            Order order = new Order();
            order.AddItem(new Item());

            OrderRepository repository = new OrderRepository();
            repository.Save(order);

            OrderViewer viewer = new OrderViewer();
            viewer.ShowOrder(order);
        }
    }
}
