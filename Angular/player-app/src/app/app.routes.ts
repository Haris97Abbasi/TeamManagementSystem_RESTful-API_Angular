import { Routes } from '@angular/router';
import { PlayerComponent } from './Components/player/player.component';

export const routes: Routes = [
    {
        path:"", component: PlayerComponent 
    },
    {
        path:"player", component: PlayerComponent
    }
];
