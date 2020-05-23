let data:number|string = 10
data = '10'

export interface ICar{
    model : string
    color : string
    topspeed? : number
}



const car1:ICar = {
    model : 'BMW',
    color : 'red'
}

const car2:ICar = {
    model : 'Mercedes',
    color : 'yellow',
    topspeed : 50
}

const multiply = (x:any,y:any):string=>{
   return  (x*y).toString()
}

export const cars = [car1, car2]