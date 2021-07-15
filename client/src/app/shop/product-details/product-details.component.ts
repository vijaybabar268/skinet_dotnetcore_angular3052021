import { ShopService } from './../shop.service';
import { IProduct } from 'src/app/shared/models/product';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})

export class ProductDetailsComponent implements OnInit {
  product: IProduct | any;

  constructor(private shopService: ShopService, private activateRoute: ActivatedRoute) { }

  ngOnInit() {
    this.loadProduct();
  }

  loadProduct(){
    this.shopService.getProduct(this.activateRoute.snapshot.paramMap.get("id")?.toString()).subscribe(res => {
      this.product = res;   
    }, error => {
      console.log(error);
    })
  }

}
