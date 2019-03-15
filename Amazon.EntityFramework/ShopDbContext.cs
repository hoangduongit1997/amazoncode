namespace Amazon.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base("name=ShopDbContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order_items> Order_items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Ref_Invoice_Status_Codes> Ref_Invoice_Status_Codes { get; set; }
        public virtual DbSet<Ref_Order_Item_Status_Codes> Ref_Order_Item_Status_Codes { get; set; }
        public virtual DbSet<Ref_Order_Status_Codes> Ref_Order_Status_Codes { get; set; }
        public virtual DbSet<Ref_Product_Types> Ref_Product_Types { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.email_address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.login_name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.login_password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.employee_id)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.employee_password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.employee_name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.email_address)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.Contain)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.Target)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.invoice_number)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.order_id)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Icon)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Properti)
                .IsUnicode(false);

            modelBuilder.Entity<Order_items>()
                .Property(e => e.order_item_id)
                .IsUnicode(false);

            modelBuilder.Entity<Order_items>()
                .Property(e => e.order_id)
                .IsUnicode(false);

            modelBuilder.Entity<Order_items>()
                .Property(e => e.product_id)
                .IsUnicode(false);

            modelBuilder.Entity<Order_items>()
                .HasMany(e => e.Shipments)
                .WithMany(e => e.Order_items)
                .Map(m => m.ToTable("Shipment_Items").MapLeftKey("order_item_id").MapRightKey("shipment_id"));

            modelBuilder.Entity<Order>()
                .Property(e => e.order_id)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.order_place)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.total_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payment>()
                .Property(e => e.payment_id)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.invoice_number)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_id)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_type_code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_size)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_color)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_imge)
                .IsUnicode(false);

            modelBuilder.Entity<Ref_Invoice_Status_Codes>()
                .Property(e => e.invoice_status_description)
                .IsUnicode(false);

            modelBuilder.Entity<Ref_Order_Item_Status_Codes>()
                .Property(e => e.order_item_status_description)
                .IsUnicode(false);

            modelBuilder.Entity<Ref_Order_Status_Codes>()
                .Property(e => e.order_status_decription)
                .IsUnicode(false);

            modelBuilder.Entity<Ref_Product_Types>()
                .Property(e => e.product_type_code)
                .IsUnicode(false);

            modelBuilder.Entity<Ref_Product_Types>()
                .Property(e => e.product_type_description)
                .IsUnicode(false);

            modelBuilder.Entity<Shipment>()
                .Property(e => e.shipment_id)
                .IsUnicode(false);

            modelBuilder.Entity<Shipment>()
                .Property(e => e.order_id)
                .IsUnicode(false);

            modelBuilder.Entity<Shipment>()
                .Property(e => e.invoice_number)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Priority)
                .IsUnicode(false);
        }
    }
}
