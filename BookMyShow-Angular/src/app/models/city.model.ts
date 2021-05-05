export class City {
    id: number;
	name: string;
    state:string;
	pincode: string;

	constructor(city: any) {
		this.id = city.id;
		this.name = city.name;
        this.state=city.state;
		this.pincode = city.pincode;
	}
}
