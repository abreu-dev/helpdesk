﻿using HelpDesk.Infra.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HelpDesk.Infra.Core.Context
{
    public interface IDataContext
    {
        bool IsAvailable();

        DbSet<TDataEntity> GetDbSet<TDataEntity>() where TDataEntity : DataEntity;
        EntityEntry<TDataEntity> GetDbEntry<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity;
        IQueryable<TDataEntity> Query<TDataEntity>() where TDataEntity : DataEntity;

        void AddData<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity;
        void UpdateData<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity;
        void DeleteData<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity;

        int CommitChanges();
        void RollBackChanges();
    }
}
