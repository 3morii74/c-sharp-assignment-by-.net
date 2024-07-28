<?php

namespace App\Http\Controllers;

use App\Http\Requests\ContactRequest;
use App\Mail\ContactMail;
use Illuminate\Support\Facades\Mail;

class ContactController extends Controller
{
    public function __invoke(ContactRequest $request)
    {
        // Increase maximum execution time to 60 seconds
        ini_set('max_execution_time', 1000);

        // Sending the email
        Mail::to('omerahmed200237@gmail.com')->send(new ContactMail($request->name, $request->email, $request->body));

        // Redirecting back to the previous page
        return redirect()->back();
    }
}
