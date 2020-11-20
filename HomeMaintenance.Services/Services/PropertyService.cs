﻿using HomeMaintenance.Data;
using HomeMaintenance.Data.DataClasses;
using HomeMaintenance.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Services.Services
{
    public class PropertyService
    {
        private readonly Guid _userId;

        public PropertyService(Guid userId)
        {
            _userId = userId;
        }
        // Create Property
        public bool CreateProperty(PropertyCreate model)
        {
            var entity =
                new Property()
                {
                    PropertyOwnerFirstName = model.PropertyOwnerFirstName,
                    PropertyOwnerLastName = model.PropertyOwnerLastName,
                    PropertyAddress = model.PropertyAddress,
                    PropertyPhone = model.PropertyPhone,
                    PropertyOwnerEmail = model.PropertyOwnerEmail
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Property.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get All Property
        public IEnumerable<PropertyListItem> GetProperty()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Property
                    .Select(
                    e =>
                    new PropertyListItem
                    {
                        PropertyID = e.PropertyID,
                        PropertyOwnerFirstName = e.PropertyOwnerFirstName,
                        PropertyOwnerLastName = e.PropertyOwnerLastName,
                        PropertyAddress = e.PropertyAddress,
                        PropertyPhone = e.PropertyPhone,
                        PropertyOwnerEmail = e.PropertyOwnerEmail
                    });
                return query.ToArray();
            }
        }

        //Get Property By ID
        public PropertyDetail GetPropertyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Property
                        .Single(e => e.PropertyID == id);
                return
                    new PropertyDetail
                    {
                        PropertyID = entity.PropertyID,
                        PropertyOwnerFirstName = entity.PropertyOwnerFirstName,
                        PropertyOwnerLastName = entity.PropertyOwnerLastName,
                        PropertyAddress = entity.PropertyAddress,
                        PropertyPhone = entity.PropertyPhone,
                        PropertyOwnerEmail = entity.PropertyOwnerEmail
                    };
            }
        }

        public bool UpdateProperty(PropertyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Property
                    .Single(e => e.PropertyID == model.PropertyID);

                entity.PropertyOwnerFirstName = model.PropertyOwnerFirstName;
                entity.PropertyOwnerLastName = model.PropertyOwnerLastName;
                entity.PropertyAddress = model.PropertyAddress;
                entity.PropertyPhone = model.PropertyPhone;
                entity.PropertyOwnerEmail = model.PropertyOwnerEmail;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProperty(int propertyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Property
                        .Single(e => e.PropertyID == propertyId);

                ctx.Property.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
