import { ShopService } from './../shop.service';
import { IProduct } from 'src/app/shared/models/product';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})

export class ProductDetailsComponent implements OnInit {
  product: IProduct | any;

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute, 
    private bcService: BreadcrumbService) { 
      this.bcService.set('@productDetails',' ');
    }

  ngOnInit() {
    this.loadProduct();
  }

  loadProduct(){
    this.shopService.getProduct(this.activateRoute.snapshot.paramMap.get("id")?.toString()).subscribe(res => {
      this.product = res;  
      this.bcService.set('@productDetails', this.product.name);
    }, error => {
      console.log(error);
    })
  }

}
