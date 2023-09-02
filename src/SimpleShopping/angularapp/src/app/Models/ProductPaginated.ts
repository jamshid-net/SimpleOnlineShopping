import { Category } from "./CategoryResponse"

export interface ProductPaginated {
    totalItems: number
    currentPage: number
    nextPage: number
    previousPage: number
    totalPages: number
    results: Product[]
  }
  
  export interface Product {
    id: number
    productName: string
    productPrice: number
    productPicture: string
    category: Category
  }
  
 