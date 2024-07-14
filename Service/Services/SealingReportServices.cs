using Entities.Models;
using Repository.Abstractions;
using Repository.Repositories;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
    public class SealingReportServices : ISealingReportService
    {
        private readonly ISealingReportRepository _sealingReportRepository;

        public SealingReportServices(ISealingReportRepository sealingReportRepository)
        {
            _sealingReportRepository = sealingReportRepository;
        }

        public Task<bool> Create(SealingReport entity)
        => _sealingReportRepository.Create(entity);

        public Task<bool> Delete(SealingReport entity)
        => _sealingReportRepository.Delete(entity);

        public List<SealingReport> FindAll()
        => _sealingReportRepository.FindAll().ToList();

        public IQueryable<SealingReport> FindByCondition(Expression<Func<SealingReport, bool>> expression, bool trackChanges)
        => _sealingReportRepository.FindByCondition(expression, trackChanges);

        public Task<bool> Update(SealingReport entity)
        => _sealingReportRepository.Update(entity);
        
        public async Task<Guid?> GetSealingReportIdByPaperIdAsync(Guid paperId)
        {
            var sr = await _sealingReportRepository
                .FindByCondition(t => t.PaperId == paperId, trackChanges: false)
                .FirstOrDefaultAsync();

            return sr?.Id;
        }
    }
}
