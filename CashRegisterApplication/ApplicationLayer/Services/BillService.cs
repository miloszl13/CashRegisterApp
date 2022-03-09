﻿using ApplicationLayer.Interfaces;
using ApplicationLayer.Model;
using ApplicationLayer.ViewModels;
using Domain;
using Domain.Commands;
using Domain.interfaces;
using DomainCore.Bus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMediatorHandler _bus;

        public BillService(IBillRepository billRepository, IMediatorHandler bus)
        {
            _billRepository = billRepository;
            _bus = bus;
        }

        public ActionResult<List<BillViewModel>> GetBills()
        {
            var bills = _billRepository.GetBills();
            if (bills.Count()==0)
            {
                var errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = BillErrorMessages.empty_bills_db,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return new NotFoundObjectResult(errorResponse);
            }
            var result = new List<BillViewModel>();
            foreach(var bill in bills)
            {
                result.Add(new BillViewModel
                {
                    Bill_number = bill.Bill_number,
                    Total_cost = bill.Total_cost,
                    Credit_card = bill.Credit_card
                });
            }
            return result;

        }
        public ActionResult<bool> Create(BillViewModel billViewModel)
        {
            var createBillCommand = new CreateBillCommand(
                billViewModel.Bill_number,
                billViewModel.Total_cost,
                billViewModel.Credit_card);
            var Task = _bus.SendCommand(createBillCommand);
            if (Task == Task.FromResult(false))
            {
                var errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = BillErrorMessages.bill_already_exist,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return new NotFoundObjectResult(errorResponse);
            }
            return true;
        }
        public ActionResult<bool> Update(BillViewModel billViewModel)
        {
            var updateBillCommand = new UpdateBillCommand(
                billViewModel.Bill_number,
                billViewModel.Total_cost,
                billViewModel.Credit_card);
                var Task=_bus.SendCommand(updateBillCommand); 
            if(Task== Task.FromResult(false))
            {
                var errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = BillErrorMessages.bill_not_exist,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return new NotFoundObjectResult(errorResponse);
            }
            return true;
             
            
            
        }
        //DELETE BILL FROM DB
        public ActionResult<int> Delete(int id)
        {

            var billfromdb = _billRepository.GetBills().FirstOrDefault(x => x.Bill_number == id);
            if (billfromdb == null)
            {
                var errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = BillErrorMessages.bill_not_exist,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return new NotFoundObjectResult(errorResponse);
            }
            _billRepository.Delete(billfromdb);
            return id;
            
            
        }
        //GET BILL BY ID
        public ActionResult<BillViewModel> GetBillById(int id)
        {
            var billfromdb = _billRepository.GetBillById(id);

            if (billfromdb == null)
            {
                var errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = BillErrorMessages.bill_not_exist,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return new NotFoundObjectResult(errorResponse);
            }
           
            
            List<BillProductViewModel> billProducts = new List<BillProductViewModel>();
            foreach(BillProduct bp in billfromdb.Bill_Products)
            {
                billProducts.Add(new BillProductViewModel
                {
                    Bill_number = bp.Bill_number,
                    Product_id = bp.Product_id,
                    Product_quantity = bp.Product_quantity,
                    Products_cost = bp.Products_cost
                });
            }
            var result = new BillViewModel
            {
                Bill_number = billfromdb.Bill_number,
                Total_cost = billfromdb.Total_cost,
                Credit_card = billfromdb.Credit_card,
                Bill_Products = billProducts
            };
            return result;
        }

    }
}
