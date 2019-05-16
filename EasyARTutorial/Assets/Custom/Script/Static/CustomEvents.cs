﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomEvents {
    public delegate void Method();

    public static event Method OnTrackingFound;
    public static void TrackingFound() {
        OnTrackingFound?.Invoke();
    }
}
