import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'races',
    templateUrl: './races.component.html'
})
export class RacesComponent {
    public races: RaceDetails[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/race').subscribe(result => {
            this.races = result.json() as RaceDetails[];
        }, error => console.error(error));
    }
}

interface RaceDetails {
    race: Race;
    status: string;
    totalPlace: number;
    Horses: HorseDetails[];
}

interface Race {
    id: number;
    name: string;
    start: Date;
    status: string;
    Horses: Horse[]
}

interface Horse {
    id: number;
    name: string;
    odds: string;
}

interface HorseDetails {
    horse: Horse;
    numberOfBets: number;
    totalPotentialPayout: number;
}