export interface ErrorResponseRoot {
    Error: string
    StatusCode: number
    IsSuccess: boolean
    Result: Result
  }
  
  export interface Result {
    Message: string
    Data: Data
    InnerException: any
    HelpLink: any
    Source: string
    HResult: number
    StackTrace: string
  }
  
  export interface Data {}